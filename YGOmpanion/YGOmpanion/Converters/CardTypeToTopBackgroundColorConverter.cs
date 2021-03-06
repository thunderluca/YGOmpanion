﻿using System;
using System.Globalization;
using Xamarin.Forms;
using YGOmpanion.Helpers;

namespace YGOmpanion.Converters
{
    public class CardTypeToTopBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Data.Models.CardType cardType)
            {
                return ColorHelper.GetTopBackgroundColor(cardType);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
