﻿using System.Windows.Controls;
using KH_Editor.Enums.DDD;
using KH_Editor.View.DebugComponent;
using KH_Editor.View.KH_DDD.DDD_btlparam;
using KH_Editor.View.KH_DDD.DDD_inventory;
using KH_Editor.View.KH_DDD.DDD_itemdata;
using KH_Editor.View.KH_DDD.DDD_Status;
using KH_Editor.View.KH_DDD.DDD_tboxdt;

namespace KH_Editor.View.Main
{
    class MainComponentLoader
    {
        public static void loadComponent(MainWindow main, Frame frame, DDD_Components component)
        {
            switch(component)
            {
                case DDD_Components.DEBUG: frame.Content = new DebugView(); break;
                case DDD_Components.STATUS: frame.Content = new DDD_StatusComponent(main); break;
                case DDD_Components.INVENTORY: frame.Content = new DDD_inventoryComponent(main); break;
                case DDD_Components.BTLPARAM: frame.Content = new DDD_btlparamComponent(main); break;
                case DDD_Components.ITEMDATA: frame.Content = new DDD_itemdataComponent(main); break;
                case DDD_Components.TBOXDTSO: frame.Content = new DDD_tboxdtComponent(main, true); break;
                case DDD_Components.TBOXDTRI: frame.Content = new DDD_tboxdtComponent(main, false); break;
                default: break;
            }
            
        }
    }
}