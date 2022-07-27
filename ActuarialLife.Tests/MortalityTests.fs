module ActuarialLife.Tests

open NUnit.Framework
open ActuarialLife.MortalityFunctions
open System

[<TestFixture>]
type TestMortality () =
    // M90 parameters
    let alpha = 0.001
    let beta = 0.000012
    let gamma = 0.044
    let c = gamma * Math.Log 10
    
    let M90 = Mortality(alpha, beta, c)

    // Life remaining at age x
    let e x = integral 0.0 150.0 (M90.lKvot x)
    

    [<Test>]
    member this.ExpectedLifeRemaining0_IsWithinTol  () =

        let tol = 1E-2
        let expected = 80.080
        let actual = e 0.0
        Assert.AreEqual(80.08, actual, tol)
        
    [<Test>]
    member this.ExpectedLifeRemaining65_IsWithinTol  () =
        let tol = 1E-2
        let expected = 20.840
        let actual = e 65.0
        Assert.AreEqual(expected, actual, tol)
        
    [<Test>]
    member this.ExpectedLifeRemaining114_IsWithinTol  () =
        let tol = 1E-2
        let expected = 0.740
        let actual = e 114.0
        Assert.AreEqual(expected, actual, tol)