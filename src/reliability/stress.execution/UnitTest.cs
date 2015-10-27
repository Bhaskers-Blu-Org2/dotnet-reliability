﻿using System;
using System.Reflection;

namespace stress.execution
{
    public class UnitTest : ITestPattern
    {
        public UnitTest(Action action = null, bool trapExceptions = true)
        {
            this.Log = new TestExecutionLog();

            this.Action = action;

            this.TrapExceptions = trapExceptions;
        }

        public Action Action { get; set; }

        public bool TrapExceptions { get; set; }

        public TestExecutionLog Log { get; private set; }

        public void Execute()
        {
            long begin = this.Log.BeginTest();

            if(this.TrapExceptions)
            {
                try
                {
                    this.Action();

                    this.Log.EndTest(begin, true);
                }
                catch
                {
                    this.Log.EndTest(begin, false);
                }
            }
            else
            {
                this.Action();

                this.Log.EndTest(begin, true);
            }
        }

        UnitTest ITestPattern.GetNextTest()
        {
            return this;
        }
    }
}