SELECT u.UserId, u.UserName, u.FirstName, u.LastName, u.Email, i.Title
FROM Users u
INNER JOIN Items i
	ON u.UserId = i.userId