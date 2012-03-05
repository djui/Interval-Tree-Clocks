// This file is a script that can be executed with the F# Interactive.  
// It can be used to explore and test the library project.
// Note that script files will not be part of the project build.
#r "../packages/Unquote.2.1.0/lib/net40/Unquote.dll"
#r "../packages/xunit.1.9.0.1566/lib/xunit.dll"
#r "System.Windows.Forms.DataVisualization"

open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

type LineChartForm( title, xs : float seq ) =
    inherit Form( Text=title )

    let chart = new Chart(Dock=DockStyle.Fill)
    let area = new ChartArea(Name="Semantic ICTs")
    let series = new Series()
    do series.ChartType <- SeriesChartType.Line
    do xs |> Seq.iter (series.Points.Add >> ignore)
    do series.ChartArea <- "Semantic ICTs"
    do chart.Series.Add( series )
    do chart.ChartAreas.Add(area)
    do base.Controls.Add( chart )

#load "ITC.fs"
open ITC
open Swensen.Unquote
open Xunit

let the_id = Tuple(One, Tuple(Zero, One))
let plotter = semfun the_id
let the_floats = seq { for x in 0.0 .. 100.0 do yield x/100.0 }
                 |> Seq.map plotter

let form = new LineChartForm("Semantic ICTs", the_floats)
form.Show()
//[<Fact>]
//let ``initial state`` =
//  