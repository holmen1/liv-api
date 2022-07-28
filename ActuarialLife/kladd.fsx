
open System
open System.Globalization

let pnr = "19660905-0098"
let pnr2 = "19770905-0098"

// split string separated by -, convert first element to date
let PnrToDate (pnr:string) =
    let provider = CultureInfo.InvariantCulture
    let format = "yyyyMMdd"
    (pnr.Split "-")[0] |> (fun d -> DateTime.ParseExact(d,format,provider))
    
// number of months between to dates
let MonthsBetween (date1:DateTime) (date2:DateTime) =
    (date2 - date1).TotalDays
    |> int
    |> (fun d -> d / 30)
    
let YearsBetween (date1:DateTime) (date2:DateTime) =
    (date2 - date1).TotalDays
    |> (fun d -> d / (12.0 * 30.0))
    
// Test MonthsBetween on pnr1 and pnr2
MonthsBetween (PnrToDate pnr) (PnrToDate pnr2) / 12

// Test YearsBetween on pnr1 and pnr2
YearsBetween (PnrToDate pnr) (PnrToDate pnr2)
