
#if INTERACTIVE
#r "System.Data"
#r "System.Data.Entity"
#r "System.Data.Linq"
#r "FSharp.Data.dll"
#r "FSharp.Data.DesignTime.dll"
#endif

open System.Data
open System.Data.Entity
open System.Data.Linq
open FSharp.Data



type InputXml = XmlProvider<"input_sample.xml">  
let sample = InputXml.Parse("""<author name="Karl Popper" born="1902" />""")

printfn "%s (%d)" sample.Name sample.Born