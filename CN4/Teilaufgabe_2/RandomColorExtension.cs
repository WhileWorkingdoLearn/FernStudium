using System;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace Teilaufgabe_2
{
    [MarkupExtensionReturnType(typeof(SolidColorBrush))]
    class RandomColorExtension : MarkupExtension
    {
        public SolidColorBrush RandomColor;

        private int alpha;

        private static Random random = new Random();

        public RandomColorExtension(): this(random.Next(155, 255)) {
        }

        public RandomColorExtension(int aplha)
        {
            this.alpha = aplha;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SolidColorBrush(Color.FromArgb((byte)alpha, (byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
        }
    }
}
