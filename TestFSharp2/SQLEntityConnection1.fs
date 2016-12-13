// The SqlEntityConnection (Entity Data Model) TypeProvider allows you to write code that uses 
// a live connection to a database that is represented by the Entity Data Model. For more information, 
// please go to 
//    http://go.microsoft.com/fwlink/?LinkId=229210

module SQLEntityConnection1

#if INTERACTIVE
#r "System.Data"
#r "System.Data.Entity"
#r "System.Data.Linq"
#r "FSharp.Data.TypeProviders"
#endif

open System.Data
open System.Data.Entity
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open System;



// You can use Server Explorer to build your ConnectionString.
type internal SqlConnection = Microsoft.FSharp.Data.TypeProviders.SqlEntityConnection<ConnectionString = @"Data Source=localhost;Initial Catalog=WECHATDB_UAT;User ID=sa;Password=sapass[];MultipleActiveResultSets=true",Pluralize = true>

let internal db = SqlConnection.GetDataContext()

let internal table1 schema batchdate = 
            query {
                    for r in db.PayerReconciliationControls do
                    where ((r.SchemeId = schema) && (r.BatchDate = batchdate))
                    select (r)
                }

//
//
//let internal table = 
//            query {
//                    for r in db.PayerReconciliationControl do
//                    join p in db.PayerReconciliation 
//                        on ((r.SchemeId,r.BatchDate) = (p.SchemeId,p.BatchDate))
//                    select (r,p)
//                }
//
