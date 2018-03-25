using System;

// smart cards libs
using PCSC;
using PCSC.Exceptions;
using PCSC.Utils;

namespace pt_legitymacjestudenckie
{
    class CardReader
    {
        // 
        SCardContext context;
        SCardReader reader;
        IntPtr protocol;
        string readerName;

        bool initialized;


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

    }
}
