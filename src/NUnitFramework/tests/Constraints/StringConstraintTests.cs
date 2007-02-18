// *****************************************************
// Copyright 2007, Charlie Poole
// Licensed under the NUnit License, see license.txt
// *****************************************************

using System;

namespace NUnit.Framework.Constraints.Tests
{
    [TestFixture]
    public class SubstringTest : ConstraintTestBase, IExpectException
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new SubstringConstraint("hello");
            GoodValues = new object[] { "hello", "hello there", "I said hello", "say hello to fred" };
            BadValues = new object[] { "goodbye", "What the hell?", string.Empty, null };
            Description = "String containing \"hello\"";
        }

        public void HandleException(Exception ex)
        {
            Assert.That(ex.Message, Is.EqualTo(
                Msgs.Pfx_Expected + "String containing \"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa...\"" + Environment.NewLine +
                Msgs.Pfx_Actual   + "\"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx...\"" + Environment.NewLine));
        }
    }

    [TestFixture]
    public class SubstringTestIgnoringCase : ConstraintTestBase
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new SubstringConstraint("hello").IgnoreCase;
            GoodValues = new object[] { "Hello", "HellO there", "I said HELLO", "say hello to fred" };
            BadValues = new object[] { "goodbye", "What the hell?", string.Empty, null };
            Description = "String containing \"hello\"";
        }
    }

    [TestFixture]
    public class StartsWithTest : ConstraintTestBase
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new StartsWithConstraint("hello");
            GoodValues = new object[] { "hello", "hello there" };
            BadValues = new object[] { "goodbye", "What the hell?", "I said hello", "say hello to fred", string.Empty, null };
            Description = "String starting with \"hello\"";
        }
    }

    [TestFixture]
    public class StartsWithTestIgnoringCase : ConstraintTestBase
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new StartsWithConstraint("hello").IgnoreCase;
            GoodValues = new object[] { "Hello", "HELLO there" };
            BadValues = new object[] { "goodbye", "What the hell?", "I said hello", "say Hello to fred", string.Empty, null };
            Description = "String starting with \"hello\"";
        }
    }

    [TestFixture]
    public class EndsWithTest : ConstraintTestBase
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new EndsWithConstraint("hello");
            GoodValues = new object[] { "hello", "I said hello" };
            BadValues = new object[] { "goodbye", "What the hell?", "hello there", "say hello to fred", string.Empty, null };
            Description = "String ending with \"hello\"";
        }
    }

    [TestFixture]
    public class EndsWithTestIgnoringCase : ConstraintTestBase//, IExpectException
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new EndsWithConstraint("hello").IgnoreCase;
            GoodValues = new object[] { "HELLO", "I said Hello" };
            BadValues = new object[] { "goodbye", "What the hell?", "hello there", "say hello to fred", string.Empty, null };
            Description = "String ending with \"hello\"";
        }
    }

    [TestFixture]
    public class EqualIgnoringCaseTest : ConstraintTestBase
    {
		[SetUp]
        public void SetUp()
        {
            Matcher = new EqualConstraint("Hello World!").IgnoreCase;
            GoodValues = new object[] { "hello world!", "Hello World!", "HELLO world!" };
            BadValues = new object[] { "goodbye", "Hello Friends!", string.Empty, null };
            Description = "\"Hello World!\"";
        }
    }
}
