using System;
using System.Collections.Generic;
using System.Drawing;

namespace Fracter2.Data.ColorTable
{
    public abstract class ScaledColorTableBase : ColorTableBase
    {
        //----------------------------------------------------------------------
        protected ScaledColorTableBase( int numberOfColors ) : base( numberOfColors )
        {}

        //----------------------------------------------------------------------
        public struct ColorScaleBuilder 
        {
            //----------------------------------------------------------------------
            public ColorScaleBuilder( float redLimit, float greenLimit, float blueLimit )
            {
                m_Red   = redLimit;
                m_Green = greenLimit;
                m_Blue  = blueLimit;
            }

            //----------------------------------------------------------------------
            public ColorScaleBuilder( Color brightest )
            {
                m_Red   = brightest.R / 255.0f;
                m_Green = brightest.G / 255.0f;
                m_Blue  = brightest.B / 255.0f;
            }

            //----------------------------------------------------------------------
            readonly float m_Red;
            public float Red { get { return m_Red; } }

            //----------------------------------------------------------------------
            readonly float m_Green;
            public float Green { get { return m_Green; } }

            //----------------------------------------------------------------------
            readonly float m_Blue;
            public float Blue { get { return m_Blue; } }

            //----------------------------------------------------------------------
            public List<Color> Build( int numberOfSteps )
            {
                var colors = new List< Color >();

                var stepR = StepSize( Red,   numberOfSteps );
                var stepG = StepSize( Green, numberOfSteps );
                var stepB = StepSize( Blue,  numberOfSteps );

				for( var i = 0; i < numberOfSteps; i++ )
//                for( var i = numberOfSteps; i > 0; i-- )
                {
                    colors.Add( Color.FromArgb( 255,
                                                Convert.ToInt32( i * stepR ),
                                                Convert.ToInt32( i * stepG ),
                                                Convert.ToInt32( i * stepB ) ) );
                }
                return colors;
            }

            //----------------------------------------------------------------------
            static float StepSize( float limit, int numberOfSteps )
            {
                return Clamp01( limit ) * 255f / numberOfSteps;
            }
        }

        //----------------------------------------------------------------------
        protected void CreateScaledColors( ColorScaleBuilder colorScaleBuilder )
        {
            Colors.Add( SetMemberColor );

            Colors.AddRange( colorScaleBuilder.Build( NumberOfColors - 1 ) );
        }
    }
}