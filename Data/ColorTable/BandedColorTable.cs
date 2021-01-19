using System.Drawing;

namespace Fracter2.Data.ColorTable
{
    public class BandedColorTable : ScaledColorTableBase, IRandomSeeded
    {
        #region Implementation of IRandomSeeded

        //----------------------------------------------------------------------
        public int Seed
        {
            get { return ColorGenerator.Seed; }
            set
            {
                if( Seed.Equals( value ) ) return;

                ColorGenerator.Seed = value;

                CreateBands( NumberOfBands );
            }
        }

        #endregion

        //----------------------------------------------------------------------
        RandomColorGenerator ColorGenerator { get; set; }

        static int NumberOfBands { get; set; }

        //----------------------------------------------------------------------
        public BandedColorTable( int numberOfColors )
            : base( numberOfColors )
        {
            NumberOfBands = 32;

            ColorGenerator = new RandomColorGenerator( 0 );
            Seed = 0;

            CreateBands( NumberOfBands );
        }

        //----------------------------------------------------------------------
        public override string ToString()
        {
            return "Banded";
        }

        //----------------------------------------------------------------------
        void CreateBands( int numberOfBands )
        {
            Colors.Clear();

            Colors.Add( SetMemberColor );

            var colorsPerBand = (NumberOfColors - 1) / numberOfBands;
            var remainderBand = (NumberOfColors - 1) % numberOfBands;

            for( var i = 0; i < numberOfBands; i++ )
            {
                AddBand( colorsPerBand, ColorGenerator.GetColor() );
            }

            if( 0 == remainderBand ) return;

            AddBand( remainderBand, ColorGenerator.GetColor() );
        }

        //----------------------------------------------------------------------
        void AddBand( int numberOfColors, Color seedColor )
        {
            var x = new ColorScaleBuilder( seedColor );

            Colors.AddRange( x.Build( numberOfColors ) );
        }
    }
}