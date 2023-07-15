using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the control setting for a serial communications device.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-dcb
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DCB
    {
        /// <summary>
        /// The length of the structure, in bytes. 
        /// The caller must set this member to sizeof(DCB).
        /// </summary>
        public uint DCBlength;

        /// <summary>
        /// The baud rate at which the communications device operates. 
        /// This member can be an actual baud rate value, or one of the following indexes(in enums).
        /// </summary>
        public uint BaudRate;

        /// <summary>
        /// fBinary : 1
        /// fParity : 1
        /// fOutxCtsFlow : 1
        /// fOutxDsrFlow : 1
        /// fDtrControl : 2
        /// fDsrSensitivity : 1
        /// fTXContinueOnXoff : 1
        /// fOutX : 1
        /// fInX : 1
        /// fErrorChar : 1
        /// fNull : 1
        /// fRtsControl : 2
        /// fAbortOnError : 1
        /// fDummy2 : 17 
        /// </summary>
        public uint bitvector1;

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public ushort wReserved;

        /// <summary>
        /// The minimum number of bytes in use allowed in the input buffer before flow control is activated to allow transmission by the sender. 
        /// This assumes that either XON/XOFF, RTS, or DTR input flow control is specified in the fInX, fRtsControl, or fDtrControl members.
        /// </summary>
        public ushort XonLim;

        /// <summary>
        /// The minimum number of free bytes allowed in the input buffer before flow control is activated to inhibit the sender. 
        /// Note that the sender may transmit characters after the flow control signal has been activated, so this value should never be zero. 
        /// This assumes that either XON/XOFF, RTS, or DTR input flow control is specified in the fInX, fRtsControl, or fDtrControl members. 
        /// The maximum number of bytes in use allowed is calculated by subtracting this value from the size, in bytes, of the input buffer.
        /// </summary>
        public ushort XoffLim;

        /// <summary>
        /// The number of bits in the bytes transmitted and received.
        /// </summary>
        public byte ByteSize;

        /// <summary>
        /// The parity scheme to be used. This member can be one of the following values(enum).
        /// </summary>
        public Parity Parity;

        /// <summary>
        /// The number of stop bits to be used. 
        /// </summary>
        public STOPBITS StopBits;

        /// <summary>
        /// The value of the XON character for both transmission and reception.
        /// </summary>
        public byte XonChar;

        /// <summary>
        /// The value of the XOFF character for both transmission and reception.
        /// </summary>
        public byte XoffChar;

        /// <summary>
        /// The value of the character used to replace bytes received with a parity error.
        /// </summary>
        public byte ErrorChar;

        /// <summary>
        /// The value of the character used to signal the end of data.
        /// </summary>
        public byte EofChar;

        /// <summary>
        /// The value of the character used to signal an event.
        /// </summary>
        public byte EvtChar;

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public ushort wReserved1;

        /// <summary>
        /// If this member is TRUE, binary mode is enabled. Windows does not support nonbinary mode transfers, so this member must be TRUE.
        /// </summary>
        public uint fBinary
        {
            get
            {
                return ((uint)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this member is TRUE, parity checking is performed and errors are reported.
        /// </summary>
        public uint fParity
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }

        public uint fOutxCtsFlow
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4u)
                            / 4)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4)
                            | this.bitvector1)));
            }
        }

        public uint fOutxDsrFlow
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8u)
                            / 8)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// DTR_CONTROL_DISABLE     :   0x00    Disables the DTR line when the device is opened and leaves it disabled.
        /// DTR_CONTROL_ENABLE      :   0x01    Enables the DTR line when the device is opened and leaves it on.
        /// DTR_CONTROL_HANDSHAKE   :   0x02    Enables DTR handshaking. If handshaking is enabled, it is an error for the application to adjust the line by using the EscapeCommFunction function.
        /// </summary>
        public uint fDtrControl
        {
            get
            {
                return ((uint)(((this.bitvector1 & 48u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this member is TRUE, 
        /// the communications driver is sensitive to the state of the DSR signal. 
        /// The driver ignores any bytes received, unless the DSR modem input line is high.
        /// </summary>
        public uint fDsrSensitivity
        {
            get
            {
                return ((uint)(((this.bitvector1 & 64u)
                            / 64)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 64)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this member is TRUE, transmission continues after the input buffer has come within XoffLim bytes of being full 
        /// and the driver has transmitted the XoffChar character to stop receiving bytes. 
        /// If this member is FALSE, transmission does not continue until the input buffer is within XonLim bytes of being empty 
        /// and the driver has transmitted the XonChar character to resume reception.
        /// </summary>
        public uint fTXContinueOnXoff
        {
            get
            {
                return ((uint)(((this.bitvector1 & 128u)
                            / 128)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 128)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Indicates whether XON/XOFF flow control is used during transmission. 
        /// If this member is TRUE, transmission stops when the XoffChar character is received and starts again when the XonChar character is received.
        /// </summary>
        public uint fOutX
        {
            get
            {
                return ((uint)(((this.bitvector1 & 256u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Indicates whether XON/XOFF flow control is used during reception. If this member is TRUE, 
        /// the XoffChar character is sent when the input buffer comes within XoffLim bytes of being full, 
        /// and the XonChar character is sent when the input buffer comes within XonLim bytes of being empty.
        /// </summary>
        public uint fInX
        {
            get
            {
                return ((uint)(((this.bitvector1 & 512u)
                            / 512)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 512)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Indicates whether bytes received with parity errors are replaced with the character specified by the ErrorChar member. 
        /// If this member is TRUE and the fParity member is TRUE, replacement occurs.
        /// </summary>
        public uint fErrorChar
        {
            get
            {
                return ((uint)(((this.bitvector1 & 1024u)
                            / 1024)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 1024)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this member is TRUE, null bytes are discarded when received.
        /// </summary>
        public uint fNull
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2048u)
                            / 2048)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2048)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// The RTS (request-to-send) flow control. This member can be one of the following values.
        /// RTS_CONTROL_DISABLE         0x00    Disables the RTS line when the device is opened and leaves it disabled.
        /// RTS_CONTROL_ENABLE          0x01    Enables the RTS line when the device is opened and leaves it on.
        /// RTS_CONTROL_HANDSHAKE       0x02    Enables RTS handshaking.The driver raises the RTS line when the "type-ahead" (input) 
        ///                                     buffer is less than one-half full and lowers the RTS line when the buffer is 
        ///                                     more than three-quarters full.If handshaking is enabled, 
        ///                                     it is an error for the application to adjust the line by using the EscapeCommFunction function.
        /// RTS_CONTROL_TOGGLE          0x03    Specifies that the RTS line will be high if bytes are available for transmission.
        ///                                     After all buffered bytes have been sent, the RTS line will be low.
        /// </summary>
        public uint fRtsControl
        {
            get
            {
                return ((uint)(((this.bitvector1 & 12288u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// If this member is TRUE, the driver terminates all read and write operations with an error status if an error occurs. 
        /// The driver will not accept any further communications operations until the application 
        /// has acknowledged the error by calling the ClearCommError function.
        /// </summary>
        public uint fAbortOnError
        {
            get
            {
                return ((uint)(((this.bitvector1 & 16384u)
                            / 16384)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16384)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        public uint fDummy2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294934528u)
                            / 32768)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32768)
                            | this.bitvector1)));
            }
        }

    }
}
