using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.PowerShell.Host.ISE;

namespace PSCodeAnalyzer.Utilities
{
    /*
    public class MultiKeyGestureConverter : TypeConverter
    {
        private static readonly KeyConverter _keyConverter = new KeyConverter();
        private static readonly ModifierKeysConverter _modifierKeysConverter = new ModifierKeysConverter();

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            Contract.Assert(value is string);

            var keyStrokes = ((string)value).Split(',');
            var firstKeyStroke = keyStrokes[0];
            var firstKeyStrokeParts = firstKeyStroke.Split('+');

            var modifierKeysConverter = new ModifierKeysConverter();
            var modifierKeys = (ModifierKeys)modifierKeysConverter.ConvertFrom(firstKeyStrokeParts[0]);
            
            var keys = new List<Key>
            {
                (Key) _keyConverter.ConvertFrom(keyStrokes[0][1]),
                (Key) _keyConverter.ConvertFrom(keyStrokes[1][1])
            };

            for (var i = 1; i < keyStrokes.Length; ++i)
            {
                keys.Add((Key)_keyConverter.ConvertFrom(keyStrokes[i]));
            }

            return new MultiKeyGesture(keys, modifierKeys);
        }
    }
    */

    //[TypeConverter(typeof(MultiKeyGestureConverter))]
    public class MultiKeyGesture : KeyGesture
    {
        private readonly IList<KeyGesture> _gestures;
        private int _index = 0;

        public MultiKeyGesture(KeyGesture[] gestures, string displayString)
            : base(gestures.First().Key, gestures.First().Modifiers, displayString)
        {
            this._gestures = gestures;
        }

        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            var args = inputEventArgs as KeyEventArgs;
            if ((args == null))
            {
                return false;
            }

            var currentGesture = _gestures[_index];

            if (currentGesture.Modifiers != Keyboard.Modifiers ||
                currentGesture.Key != args.Key)
            {
                _index = 0;
                return false;
            }

            //Match current gesture
            //check if next gesture exist
            if (_index + 1 < _gestures.Count)
            {
                //next key input
                ++_index;
                inputEventArgs.Handled = true;
                return false;
            }

            //Match all gesture
            _index = 0;
            return true;
        }
    }
}
