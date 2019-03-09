﻿using System;
using System.Runtime.InteropServices;

using Windows.ApplicationModel.Resources;

namespace CourierManagement.Helpers
{
    /// <summary>
    /// Statyczna klasa z metodami rozszerzającymi możliwości dotyczące zasobów aplikacji
    /// </summary>
    internal static class ResourceExtensions
    {
        private static ResourceLoader _resLoader = new ResourceLoader();
        /// <summary>
        /// Metoda pozwalająca zwrócić przetłumaczoną wartość z zasobów, na podstawie klucza zasobu i domyślnego języka systemu Windows 
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public static string GetLocalized(this string resourceKey)
        {
            return _resLoader.GetString(resourceKey);
        }
    }
}
