using System.Reflection.Emit;

namespace AttrRead
{
    public class Instruction
    {
        public int StartOffset
        {
            get; private set;
        }
        public OpCode OpCode
        {
            get; private set;
        }
        public long? Argument
        {
            get; private set;
        }
        public Instruction(int startOffset, OpCode opCode, long? argument)
        {
            StartOffset = startOffset;
            OpCode = opCode;
            Argument = argument;
        }
        public override string ToString()
        {
            return OpCode.ToString() + (Argument == null ? string.Empty : " " + Argument.Value);
        }
    }
}