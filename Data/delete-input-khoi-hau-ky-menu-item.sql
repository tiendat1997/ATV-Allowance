use ATVAllowance

delete from RoleHasMenuItem where MenuItemId = (
	select Id from MenuItem where Name = N'Nhập Khối hậu kỳ biên soạn tnnm'
)

delete from MenuItem where Name = N'Nhập Khối hậu kỳ biên soạn tnnm'

