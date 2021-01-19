using System;
using System.Drawing;

namespace Fracter2.Data.ColorTable
{
    class RandomColorGenerator
    {
        //----------------------------------------------------------------------
        int m_Seed;
        public int Seed
        {
            get { return m_Seed; }
            set
            {
                if( m_Seed.Equals( value ) ) return;

                m_Seed = value;

                Random = new Random( m_Seed );
            }
        }

        //----------------------------------------------------------------------
        Random Random { get; set; }

        //----------------------------------------------------------------------
        public RandomColorGenerator( int seed )
        {
            Random = new Random( seed );
            Seed = seed;
        }

        //----------------------------------------------------------------------
        public Color GetColor()
        {
            return Color.FromArgb( 255, Random.Next( 255 ), Random.Next( 255 ), Random.Next( 255 ) );
        }
    }
}