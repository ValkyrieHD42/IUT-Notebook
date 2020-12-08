using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestLogic
{
    /// <summary>
    /// Test pour la classe PedagogicalElement
    /// </summary>
    public class TestPedagogicalElement
    {
        /// <summary>
        /// Test  du nom
        /// </summary>
        [Fact]
        public void TestName()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            pedagogicalElement.Name = "Test";
            Assert.Equal("Test", pedagogicalElement.Name);
        }

        /// <summary>
        /// Test du nom, ne doit pas être vide, renvoi une exception
        /// </summary>
        [Fact]
        public void TestNameEmpty()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            Assert.Throws<Exception>(() => {
                pedagogicalElement.Name = "";
            });
        }

        /// <summary>
        /// Test du nom, ne doit pas être null, renvoi une exception
        /// </summary>
        [Fact]
        public void TestNameNull()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            Assert.Throws<Exception>(() => {
                pedagogicalElement.Name = null;
            });
        }

        /// <summary>
        /// Test du coef
        /// </summary>
        [Fact]
        public void TestCoef()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            pedagogicalElement.Coef = 2.5f;
            Assert.Equal(2.5f, pedagogicalElement.Coef, 2);
        }

        /// <summary>
        /// Test du coef, ne doit pas être égale à 0, renvoi une exception
        /// </summary>
        [Fact]
        public void TestCoefZero()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            Assert.Throws<Exception>(() => {
                pedagogicalElement.Coef = 0;
            });
        }

        /// <summary>
        /// Test du coef, ne doit pas être négatif, renvoi une exception
        /// </summary>
        [Fact]
        public void TestCoefInferior()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            Assert.Throws<Exception>(() => {
                pedagogicalElement.Coef = -1;
            });
        }

        /// <summary>
        /// Test du ToString
        /// </summary>
        [Fact]
        public void TestToString()
        {
            PedagogicalElement pedagogicalElement = new PedagogicalElement();
            pedagogicalElement.Coef = 2.5f;
            pedagogicalElement.Name = "Maths";
            Assert.Equal("Maths (2,5)", pedagogicalElement.ToString());
        }
        [Fact]
        public void TestEquals()
        {
            PedagogicalElement pe1 = new PedagogicalElement();
            pe1.Coef = 2.5f;
            pe1.Name = "Maths";

            PedagogicalElement pe2 = new PedagogicalElement();
            pe2.Coef = 2.5f;
            pe2.Name = "Maths";

            Assert.True(pe1.Equals(pe2));
        }
    }
}
