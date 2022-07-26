namespace Quadrature


module Simpson =
    let compositeSimpson n a b f =
        match n with
            | even when even % 2 = 0 -> ()
            |_ -> invalidArg "n" "must be even"
            
        let h = (b - a) / float n

        h / 3.0 * (f a
                    + 4.0 * ([1..n/2] |> List.sumBy (fun i -> f (a + (2.0 * float i - 1.0) * h))) 
                    + 2.0 * ([1..n/2-1] |> List.sumBy (fun i -> f (a + 2.0 * float i * h)))
                    + f b)