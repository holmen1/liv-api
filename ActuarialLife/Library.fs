namespace ActuarialLife

open System
open Quadrature
        
module MortalityFunctions =
    let integral = Simpson.compositeSimpson 1000
        
    type Mortality(a:float, b:float, c:float) =
        let mu x = a + b * Math.Exp (c*x)
        let infinity = 150.0
        let mortality x = mu x
        // l
        let survival x = Math.Exp (-integral 0.0 x mortality)
        // lKvot
        member this.lKvot x t = survival (x + t) / survival x