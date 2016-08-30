SELECT        TOP (200) RNo, MenuID, MenuName, MenuNameB, ModID, MenuGroupID, MenuGroupSeqNo, MenuSeqNo, ConcurrencyId, CreatedBy, CreatedOn, ModifiedBy, 
                         ModifiedOn, PageName
FROM            Menu
WHERE        (ModID = 1) AND (MenuGroupID = N'M1')
ORDER BY MenuSeqNo

UPDATE Menu set MenuSeqNo = '5' Where MenuID = 'M910' and RNo = '2599'
UPDATE Menu set MenuSeqNo = '6' Where MenuID = 'M246' and RNo = '115'
UPDATE Menu set MenuSeqNo = '7' Where MenuID = 'M247' and RNo = '116'
UPDATE Menu set MenuSeqNo = '8' Where MenuID = 'M587' and RNo = '590'
UPDATE Menu set MenuSeqNo = '9' Where MenuID = 'M248' and RNo = '117'
UPDATE Menu set MenuSeqNo = '10' Where MenuID = 'M249' and RNo = '119'
UPDATE Menu set MenuSeqNo = '11' Where MenuID = 'M250' and RNo = '120'
UPDATE Menu set MenuSeqNo = '12' Where MenuID = 'M312' and RNo = '571'
UPDATE Menu set MenuSeqNo = '13' Where MenuID = 'M285' and RNo = '568'
UPDATE Menu set MenuSeqNo = '14' Where MenuID = 'M586' and RNo = '587'
UPDATE Menu set MenuSeqNo = '15' Where MenuID = 'M992' and RNo = '1598'
UPDATE Menu set MenuSeqNo = '16' Where MenuID = 'M990' and RNo = '595'