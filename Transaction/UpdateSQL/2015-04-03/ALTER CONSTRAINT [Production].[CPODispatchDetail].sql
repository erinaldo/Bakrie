


ALTER TABLE [Production].[CPODispatchDetail] DROP CONSTRAINT [PK_CPODispatchDetail]
ALTER TABLE [Production].[CPODispatchDetail] ADD CONSTRAINT [PK_CPODispatchDetail_1] PRIMARY KEY ([DispatchDetailID],[DispatchID])