namespace DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addlogstoreprocedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                    "[dbo].[InsertSystemLog]",
                    p => new
                    {
                        level = p.String(),
                        caller = p.String(),
                        type = p.String(),
                        message = p.String(),
                        stackTrace = p.String(),
                        innerException = p.String(),
                        additionalInfo = p.String()
                    },
                    @"insert into [dbo].[SystemLog]
                    (
	                    [Level],
	                    [Caller],
	                    [Type],
	                    [Message],
	                    [StackTrace],
	                    [InnerException],
	                    [AdditionalInfo]
                    )
                    values
                    (
	                    @level,
	                    @caller,
	                    @type,
	                    @message,
	                    @stackTrace,
	                    @innerException,
	                    @additionalInfo
                    )"
                );

            CreateStoredProcedure(
                    "[dbo].[InsertBusinessLog]",
                    p => new
                    {
                        actorId = p.Int(),
                        message = p.String(),
                        type = p.String(),
                        status = p.String()
                    },
                    @"insert into [dbo].[BusinessLog]
                    (
	                    [ActorId],
	                    [Message],
	                    [Type],
	                    [Status]
                    )
                    values
                    (
	                    @actorId,
	                    @message,
	                    @type,
	                    @status
                    )"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("[dbo].[InsertSystemLog]");
            DropStoredProcedure("[dbo].[InsertBusinessLog]");
        }
    }
}
