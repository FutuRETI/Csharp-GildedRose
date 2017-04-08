using System;
using System.IO;
using System.Text;
using GildedRose;
using NUnit.Framework;
using ApprovalTests.Reporters;
using ApprovalTests;

/**
 * Questa classe contiene un esempio di un test Golden Master che potrete utilizzare
 * per creare un test da rieseguire ogni operazione di refactoring che dovrete fare.
 * 
 * Le nuove funzionalità implementate avranno dei loro test di unità che scriverete
 * insieme al codice della funzionalità stessa. Il test Golden Master qui creato
 * vi servirà per verificare che i refactoring e le nuove funzionalità non abbiano
 * creato delle regressioni nel codice esistente.
 **/
namespace GildedRoseTests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class GoldmasterTest
    {
        [Test]
        public void GoldenMasterTest()
        {
            // given
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            // when
            Program.Main(new string[] { });
            string output = fakeoutput.ToString();

            // then
            Approvals.Verify(output);
        }
    }
}