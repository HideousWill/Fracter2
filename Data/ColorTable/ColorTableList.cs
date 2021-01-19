using System.Collections.Generic;
using Fracter2.Common;

namespace Fracter2.Data.ColorTable
{
    public class ColorTableList : List<ColorTableBase>
    {
        //----------------------------------------------------------------------
        public ColorTableList()
        {
            BuildColorTables( 256 );
        }

        //----------------------------------------------------------------------
        void BuildColorTables( int numberOfColors )
        {
            AddRange( Helpers.GetInstancesOfTypesImplementing<ColorTableBase, int>( numberOfColors ) );
        }
    }
}
