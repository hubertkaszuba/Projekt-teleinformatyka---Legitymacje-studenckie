using System;

// smart cards libs
using PCSC;
using PCSC.Exceptions;
using PCSC.Utils;

namespace pt_legitymacjestudenckie
{
    class CardReader
    {
        // Parametry obsługi sesji czytnika
        SCardContext context;
        SCardReader reader;
        IntPtr protocol;
        string readerName;

        const int BUFFER_SIZE = 1024;

        // Flagi pomocnicze
        bool initialized;

        // Komendy:
        // SELECT FILE DF.SELS - by AID (D6 16 00 00 30 01)
        byte[] cmdSelectAID = new byte[] { 0x00, 0xA4, 0x04, 0x00, 0x07,
                        0xD6, 0x16, 0x00, 0x00, 0x30, 0x01, 0x01, 0x00 };
        // SELECT FILE - EF.ELS
        byte[] cmdSelectELS = new byte[] { 0x00, 0xA4, 0x02, 0x00, 0x02,
                        0x00, 0x02, 0x12 };
        // READ LINE
        byte[] cmdReadLine = new byte[] { 0x00, 0xB0, 0x00, 0x00, 0xB0 };

        public CardReader()
        {
            initialized = false;
        }

        public bool Initialize()
        {
            try
            {
                // Rozpocznij nową sesję
                context = new SCardContext();
                context.Establish(SCardScope.System);

                // Pobierz listę wszystkich czytników
                // - zakładamy że czytnik w systemie jest tylko jeden
                string[] lReaders = context.GetReaders();
                if (lReaders.Length <= 0)
                {
                    throw new PCSCException(SCardError.NoReadersAvailable,
                        "Nie można znaleźć żadnego czytnika.");
                }
                readerName = lReaders[0];

                // Stwórz nowy obiekt czytnika dla tej sesji
                reader = new SCardReader(context);

                initialized = true;
                return true;
            }
            catch (PCSCException ex)
            {
                return false;
            }
        }

        public bool Connect()
        {
            try
            {
                if (!initialized)
                    throw new Exception("Urządzenie nie zainicjowane.");

                // Połącz się z czytnikiem
                SCardError err = reader.Connect(readerName,
                    SCardShareMode.Exclusive,
                    SCardProtocol.T0 | SCardProtocol.T1);
                if (err != SCardError.Success)
                    throw new PCSCException(err,
                        SCardHelper.StringifyError(err));

                // Określ strukturę protokołu
                switch (reader.ActiveProtocol)
                {
                    case SCardProtocol.T0:
                        protocol = SCardPCI.T0;
                        break;
                    case SCardProtocol.T1:
                        protocol = SCardPCI.T1;
                        break;
                    default:
                        throw new PCSCException(SCardError.ProtocolMismatch,
                            "Protokół " + reader.ActiveProtocol.ToString() +
                            "jest nieobsługiwany.");
                }

                return true;
            }
            catch (PCSCException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Release()
        {
            if (!initialized)
                throw new Exception("Urządzenie nie zainicjowane.");

            context.Release();
            initialized = false;
        }

        public int ReadData()
        {
            try
            {
                // Bufor odbieranej wiadomości
                byte[] recMessage = new byte[BUFFER_SIZE/2];
                byte[] readedMessage = new byte[BUFFER_SIZE];

                // Komenda SELECT - DF.SELS
                SCardError err = reader.Transmit(protocol, cmdSelectAID, ref recMessage);
                CheckError(err);

                // Komenda SELECT - EF.ELS
                err = reader.Transmit(protocol, cmdSelectELS, ref recMessage);
                CheckError(err);

                // Komenda READ LINE
                err = reader.Transmit(protocol, cmdReadLine, ref readedMessage);
                CheckError(err);

                return readedMessage.Length;
            }
            catch (PCSCException ex)
            {

                return -1;
            }
        }

        private void CheckError(SCardError err)
        {
            if (err != SCardError.Success)
                throw new PCSCException(err,
                    SCardHelper.StringifyError(err));
        }

    }
}
