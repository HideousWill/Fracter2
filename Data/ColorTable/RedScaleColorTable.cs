namespace Fracter2.Data.ColorTable
{
    public class RedScaleColorTable : ScaledColorTableBase
    {
        //----------------------------------------------------------------------
        public RedScaleColorTable( int numberOfColors ) : base( numberOfColors )
        {
            CreateScaledColors( new ColorScaleBuilder( 1.0f, 0f, 0f ) );
        }

        //----------------------------------------------------------------------
        public override string ToString()
        {
            return "Red-scale";
        }
    }
}