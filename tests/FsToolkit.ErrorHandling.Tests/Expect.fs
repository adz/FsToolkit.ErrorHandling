module Expect

open Expecto
let hasOkValuePredicate f x =
  match x with
  | Result.Ok v -> 
    if f v then 
      () 
    else 
      Tests.failtestf "Predicate failed for Ok's Value"
  | Result.Error x -> 
    Tests.failtestf "Expected Ok, was Error(%A)." x

let hasErrorValue v x =
  match x with
  | Ok x -> 
    Tests.failtestf "Expected Error, was Ok(%A)." x
  | Error x when x = v -> ()
  | Error x -> 
    Tests.failtestf "Expected Error(%A), was Error(%A)." v x

let hasOkValue v x =
  match x with
  | Ok x when x = v -> ()
  | Ok x ->
    Tests.failtestf "Expected Ok(%A), was Ok(%A)." v x
  | Error x -> 
    Tests.failtestf "Expected Ok, was Error(%A)." x
