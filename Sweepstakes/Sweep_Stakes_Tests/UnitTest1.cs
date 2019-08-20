using System;
using Sweep_Stakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sweep_Stakes_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddContestant_AddSingleContestantToDictionary_AddsToDictionary()
        {
            Sweepstakes test = new Sweepstakes("testSweeps");
            Contestant newContestant = new Contestant();
            newContestant.firstName = "Charlie";
            newContestant.lastName = "Clark";
            newContestant.emailAddress = "ctcb57@gmail.com";
            int expected = 1;
            int actual;

            test.RegisterContestant(newContestant);
            actual = test.contestants.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void PickWinner_PickSingleWinner_WinnerIsShown()
        {
            Sweepstakes test = new Sweepstakes("testSweeps");
            Contestant newContestant = new Contestant();
            newContestant.firstName = "Charlie";
            newContestant.lastName = "Clark";
            newContestant.emailAddress = "ctcb57@gmail.com";
            newContestant.registrationNumber = 1;
            string expected = "Charlie Clark";
            string actual;

            actual = test.PickWinner();

            Assert.AreEqual(expected, actual);
        }
    }
}
