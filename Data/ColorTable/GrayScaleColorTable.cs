namespace Fracter2.Data.ColorTable
{
    public class GrayScaleColorTable : ScaledColorTableBase
    {
        //----------------------------------------------------------------------
        public GrayScaleColorTable( int numberOfColors ) : base( numberOfColors )
        {
            CreateScaledColors( new ColorScaleBuilder( 1.0f, 1.0f, 1.0f ) );
        }

        //----------------------------------------------------------------------
        public override string ToString()
        {
            return "Gray-scale";
        }
    }
}