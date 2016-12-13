// 請參閱 http://fsharp.net，進一步了解 F#
// 請參閱「F# 教學課程」專案，取得更多說明。

open System
open System.Collections
open System.Xml.Linq
open SQLEntityConnection1
open FSharp.Data

[<Literal>]
let connstring = @"Data Source=localhost;Initial Catalog=WECHATDB_UAT;User ID=sa;Password=sapass[];MultipleActiveResultSets=true"
type wechatdb = SqlProgrammabilityProvider<connstring>

[<EntryPoint>]
let main argv = 

//        type InputXml = XmlProvider<"input_sample.xml">  
//
//        type Author = Microsoft.FSharp.Data.TypeProviders.XmlProvider<"""<author name="Paul Feyerabend" born="1924" />""">
//        let sample = Author.Parse("""<author name="Karl Popper" born="1902" />""")
//
//        printfn "%s (%d)" sample.Name sample.Bor
//
//        let printsub p:SqlConnection.ServiceTypes.PayerReconciliation =
//             printfn "交易編號:%s" p.TxNo
        
        let recons schema datestr = 
            table1 schema datestr
            |> Seq.iter (fun (p) -> printfn "批次日期:%s" p.BatchDate;p.PayerReconciliations 
                                                        |> Seq.iter(fun p -> printfn "交易編號:%s" p.TxNo))

        Console.Write("input schemaid :")
        let inputSchema  =  Console.ReadLine()
        Console.Write("input batchdate :")
        let inputDatestr  =  Console.ReadLine()
        recons inputSchema inputDatestr
//        let inputargParse arg =
//            let headArg = (fun (arg:string) -> arg.Split ':' )
//            let headFirst:string = headArg.[0]:string
//            match headFirst with
//            |"-s" -> printfn "input %s" arg 
//            |"-d" -> printfn "input %s" arg 
//            |_ -> printfn "input %s" arg
//             
//        argv |> Seq.iter(fun input -> inputargParse input)

//        let result = db.DataContext.ExecuteStoreQuery(String.Format("exec spGetSerialCode {0},{1},{2},{3}","XmlFile","1","2",3))
       
        
//        result |> Seq.iter(fun r -> printf "%A" r) 

         

        //呼叫Store Procedure
        use cmd = new wechatdb.dbo.spGetSerialCode(connstring)
        for x in cmd.Execute("XmlFile","1","2",3) do
            match x with
            |Some result -> printfn "%s" (result)
            | _ -> () 
        
       //呼叫sql command
        use cmd = new SqlCommandProvider<"select * from PayerReconciliation where SchemeId = @schemaid and BatchDate = @batchdate",connstring>(connstring) 
        let result = cmd.Execute(schemaid = "wechat1",batchdate = "20161025") 
        for x in result do
            printfn "%s" (x.TxNo)   

        Console.ReadKey()

        0 // 傳回整數的結束代碼
