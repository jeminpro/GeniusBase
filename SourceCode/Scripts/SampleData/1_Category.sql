use GeniusBase
go

insert into post.Category
(CategoryName, CategoryIdentifier, CreatedBy, ModifiedBy, CreatedOn, ModifiedOn)
Values
('C#', 'c#', 1, 1, GETDATE(), GETDATE()),
('Java Script', 'java-script', 1, 1, GETDATE(), GETDATE()),
('SQL', 'sql', 1, 1, GETDATE(), GETDATE()),
('HTML', 'html', 1, 1, GETDATE(), GETDATE()),
('CSS', 'css', 1, 1, GETDATE(), GETDATE())

select * from post.Category
