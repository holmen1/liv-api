module Quadrature.Tests


open System
open NUnit.Framework
open Quadrature.Simpson

[<SetUp>]
let Setup () =
    ()

[<Test>]
let IntegrateSin_0_pi_IsWithinTol () =
    let tol = 1E-6
    let quad10_0_pi = compositeSimpson 100 0.0 Math.PI
    let res = quad10_0_pi Math.Sin
    let expected = 2.0
    Assert.AreEqual(expected, res, tol)
    
[<Test>]
let IntegrateErf_0_1_IsWithinTol () =
    let tol = 1E-9
    let integrate = compositeSimpson 10000
    let erf x = 2.0 / Math.Sqrt Math.PI * Math.Exp -(x**2)
    let res = integrate 0.0 1.0 erf
    let expected = 0.842700793
    Assert.AreEqual(expected, res, tol) 

[<Test>]  
let IntegrateSin_0_pi_WithUnevenIntervals_IsThrowingInvalidArgException () =
    let quad101_0_pi = compositeSimpson 101 0.0 Math.PI
    let res =
        try
            quad101_0_pi Math.Sin
        with
            | :? ArgumentException -> 999.9
    let expected = 999.9
  
    Assert.AreEqual(expected, res)