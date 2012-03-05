// Learn more about F# at http://fsharp.net

module ITC

type Id = Zero | One | Tuple of Id * Id
//let (|Zero|) = 0
//let (|One|)  = 1

let zero x = 0.0
let one x =
  match x with
  | _ when x >= 0.0 && x < 1.0 -> 1.0
  | _ -> 0.0

let x2 x = 2.0 * x
let rec semfun id =
  match id with 
  | Zero -> zero
  | One  -> one
  | Tuple(i', i'') -> (fun x -> (semfun i')(x2 x) + (semfun i'')(x2 x - 1.0))

