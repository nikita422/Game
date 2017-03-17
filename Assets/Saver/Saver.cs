using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Out
{
    public static class Saver
    {

        /*
         получение данных с сервера
         анкрипт и сохранение 
         все данные хранить в одном файле
         нужно хранить:
            Все корабли, их имена
             */
        public static Save save;
        public static Ship NowShips;

        static Saver()
        {
            save=Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<Save>("C:/save.xml");          
            Debug.Log("load_save_ok");
        }


        public static void Save()
        {
            Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Save<Save>("C:/save.xml", save);
        }
     
    


    }
}