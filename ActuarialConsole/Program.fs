open ActuarialLife.MortalityFunctions
open System

// M90 parameters
let alpha = 0.001
let beta = 0.000012
let gamma = 0.044
let c = gamma * Math.Log 10

let M90 = Mortality(alpha, beta, c)

// Life remaining at age x
let e x = integral 0.0 150.0 (M90.lKvot x)

[0.0; 55.0; 85.0] |> List.map (fun x -> (x, e x))
                  |> List.map (fun (x,ex) -> printfn $"e%f{x} = %f{ex}") |> ignore


