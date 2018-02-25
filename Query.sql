SELECT DISTINCT CR.Name FROM CustomerRegistration CR WITH(NOLOCK) 
INNER JOIN CustomerPurchase CP WITH(NOLOCK) ON CR.CustomerId=CP.CustomerId 
WHERE CP.ProductName LIKE '%молоко%' AND (CP.ProductName LIKE '%сметана%' AND CP.PurchaiseDatetime >= DATEADD(MONTH, -1, GETDATE())