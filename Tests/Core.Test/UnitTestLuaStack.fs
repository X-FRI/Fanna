module Fanna.Tests.Core.LuaStack

open Fanna.Core.LuaStack
open Fanna.Core.LuaValue
open NUnit.Framework

[<TestFixture>]
type TestLuaStack() =

    [<Test>]
    static member ``LuaStack.Pop``() =
        let stack = LuaStack(1)

        try
            stack.Pop() |> ignore
        with :? System.ArgumentOutOfRangeException ->
            Assert.Pass()

        Assert.AreEqual(0, stack.Length)

    [<Test>]
    static member ``LuaStack.Push``() =
        let stack = LuaStack(1)
        stack.Push(LUA_TNIL)

        Assert.AreEqual(1, stack.Length)
        Assert.AreEqual(LUA_TNIL, stack.Pop())


    [<Test>]
    static member ``LuaStack.Length``() =
        let stack = LuaStack(1)
        stack.Push(LUA_TNIL)
        printfn $"{stack.Length}"

        Assert.AreEqual(1, stack.Length)

    [<Test>]
    static member ``LuaStack.Get``() =
        let stack = LuaStack(1)
        stack.Push(LUA_TNIL)

        Assert.AreEqual(LUA_TNIL, stack.Get(1))

    [<Test>]
    static member ``LuaStack.Get (negative index)``() =
        let stack = LuaStack(1)
        stack.Push(LUA_TNIL)

        Assert.AreEqual(LUA_TNIL, stack.Get(-1))

    [<Test>]
    static member ``LuaStack.Set``() =
        let stack = LuaStack(1)
        stack.Set(1, LUA_TNIL)

        Assert.AreEqual(LUA_TNIL, stack.Get(1))

    [<Test>]
    static member ``LuaStack.Set (negative index)``() =
        let stack = LuaStack(1)
        stack.Set(-1, LUA_TNIL)

        Assert.AreEqual(LUA_TNIL, stack.Get(1))
