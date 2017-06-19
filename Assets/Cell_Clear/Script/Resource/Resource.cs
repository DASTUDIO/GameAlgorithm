using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.STUDIO
{

    public class Resource 
    {

        #region AirCubeBuffer

        AirCubeBuffer acb = new AirCubeBuffer();

        public AirCubeBuffer getAirCubeBuffer()
        {
            return this.acb;
        }

        #endregion


        #region Theme

        private Itheme theme;

        public Itheme getCurrentTheme()
        {
            return this.theme;
        }

        public void setCurrentTheme(Itheme theme)
        {
            this.theme = theme;
            this.theme.applyBackGround();
        }

        #endregion


        #region Singleton

        private static Resource r = new Resource();
        public static Resource getResource()
        {
            return r;
        }

        #endregion

    }

}