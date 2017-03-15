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

     
        //  shipsName.Add( (shipsName.Count+1).ToString());
        public static void saveActiveShip()
        {
            
           // Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Save<List<string>>("C:/"+NowShips.name +".xml", _ship);
        }

        public static void start()
        {
         //   nameShips=Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<List<string>>("C:/ships.xml");
           // for (int i = 0; i < nameShips.Count; i++)
        //    {
         //       ships.Add(Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<Ship>("C:/"+nameShips[i]+".xml"));
        //    }
        }
       

    }
}