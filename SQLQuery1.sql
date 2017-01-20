select op.Name--, AVG(opr.ExecTimeMs) 
from OperationResult as opr
join Operation as op ON op.Id = opr.OperationId
where opr.ArgumentCount=1
GROUP BY op.Name
having AVG(opr.ExecTimeMs) > 100000
