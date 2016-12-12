#r "c:\\Program Files (x86)\\Reference Assemblies\\Microsoft\\Framework\\.NETFramework\\v4.5\\System.Xml.Linq.dll"


open FSharp.Data
open System
open System.Collections.Generic
open System.Linq
open System.Xml.Linq

type Author = XmlProvider<"""<author name="Paul Feyerabend" born="1924" />""">
let sample = Author.Parse("""<author name="Karl Popper" born="1902" />""")

printfn "%s (%d)" sample.Name sample.Born

(*
let xmlstr = "<xml><test>myxml</test></xml>"
let xmlsource = XDocument.Parse(xmlstr)
for e in xmlsource.Element("xml").Elements("test") do
	printfn "%s" e.Value
*)

