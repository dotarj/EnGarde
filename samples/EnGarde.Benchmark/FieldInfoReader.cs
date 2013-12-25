// All credits of this class go to Rinat Abdullin and Matt Davis
// http://abdullin.com/journal/2008/12/13/how-to-find-out-variable-or-parameter-name-in-c.html
// http://bronumski.blogspot.nl/2010/06/taking-pain-out-of-parameter-validation.html

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace EnGarde.Benchmark
{
    internal class FieldInfoReader<TParameter>
    {
        private readonly Func<TParameter> arg;

        internal FieldInfoReader(Func<TParameter> arg)
        {
            this.arg = arg;
        }

        public FieldInfo GetFieldToken()
        {
            byte[] methodBodyIlByteArray = GetMethodBodyIlByteArray();

            int fieldToken = GetFieldToken(methodBodyIlByteArray);

            return GetFieldInfo(fieldToken);
        }

        private FieldInfo GetFieldInfo(int fieldToken)
        {
            FieldInfo fieldInfo = null;

            if (fieldToken > 0)
            {
                Type argType = arg.Target.GetType();
                Type[] genericTypeArguments = GetSubclassGenericTypes(argType);
                Type[] genericMethodArguments = arg.Method.GetGenericArguments();

                fieldInfo = argType.Module.ResolveField(fieldToken, genericTypeArguments, genericMethodArguments);
            }

            return fieldInfo;
        }

        private static OpCode GetOpCode(byte[] methodBodyIlByteArray, ref int currentPosition)
        {
            ushort value = methodBodyIlByteArray[currentPosition++];

            return value != 0xfe ? SingleByteOpCodes[value] : OpCodes.Nop;
        }

        private static int GetFieldToken(byte[] methodBodyIlByteArray)
        {
            int position = 0;

            while (position < methodBodyIlByteArray.Length)
            {
                OpCode code = GetOpCode(methodBodyIlByteArray, ref position);

                if (code.OperandType == OperandType.InlineField)
                {
                    return ReadInt32(methodBodyIlByteArray, ref position);
                }

                position = MoveToNextPosition(position, code);
            }

            return 0;
        }

        private static int MoveToNextPosition(int position, OpCode code)
        {
            switch (code.OperandType)
            {
                case OperandType.InlineNone:
                    break;

                case OperandType.InlineI8:
                case OperandType.InlineR:
                    position += 8;
                    break;

                case OperandType.InlineField:
                case OperandType.InlineBrTarget:
                case OperandType.InlineMethod:
                case OperandType.InlineSig:
                case OperandType.InlineTok:
                case OperandType.InlineType:
                case OperandType.InlineI:
                case OperandType.InlineString:
                case OperandType.InlineSwitch:
                case OperandType.ShortInlineR:
                    position += 4;
                    break;

                case OperandType.InlineVar:
                    position += 2;
                    break;

                case OperandType.ShortInlineBrTarget:
                case OperandType.ShortInlineI:
                case OperandType.ShortInlineVar:
                    position++;
                    break;

                default:
                    throw new InvalidOperationException("Unknown operand type.");
            }
            return position;
        }

        private byte[] GetMethodBodyIlByteArray()
        {
            MethodBody methodBody = arg.Method.GetMethodBody();

            if (methodBody == null)
            {
                throw new InvalidOperationException();
            }

            return methodBody.GetILAsByteArray();
        }

        private static int ReadInt32(byte[] il, ref int position)
        {
            return ((il[position++] | (il[position++] << 8)) | (il[position++] << 0x10)) | (il[position++] << 0x18);
        }

        private static Type[] GetSubclassGenericTypes(Type toCheck)
        {
            var genericArgumentsTypes = new List<Type>();

            while (toCheck != null)
            {
                if (toCheck.IsGenericType)
                {
                    genericArgumentsTypes.AddRange(toCheck.GetGenericArguments());
                }

                toCheck = toCheck.BaseType;
            }

            return genericArgumentsTypes.ToArray();
        }

        private static OpCode[] singleByteOpCodes;

        public static OpCode[] SingleByteOpCodes
        {
            get
            {
                if (singleByteOpCodes == null)
                {
                    LoadOpCodes();
                }
                return singleByteOpCodes;
            }
        }

        private static void LoadOpCodes()
        {
            singleByteOpCodes = new OpCode[0x100];

            FieldInfo[] opcodeFieldInfos = typeof(OpCodes).GetFields();

            for (int i = 0; i < opcodeFieldInfos.Length; i++)
            {
                FieldInfo info1 = opcodeFieldInfos[i];

                if (info1.FieldType == typeof(OpCode))
                {
                    var singleByteOpCode = (OpCode)info1.GetValue(null);

                    var singleByteOpcodeIndex = (ushort)singleByteOpCode.Value;

                    if (singleByteOpcodeIndex < 0x100)
                    {
                        singleByteOpCodes[singleByteOpcodeIndex] = singleByteOpCode;
                    }
                }
            }
        }
    }
}
