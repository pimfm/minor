CREATE PROCEDURE [dbo].[csp_newClient_i]
	@countryId int = 0,
	@new_identity int output
AS
BEGIN TRANSACTION

	Insert into Clients(Country_id) values(@countryId);
	SELECT @new_identity = SCOPE_IDENTITY()

	IF @@ERROR <> 0
            BEGIN
                -- Rollback the Transaction
                ROLLBACK
                RAISERROR ('Error in saving', 16, 1)
                RETURN
            END

   COMMIT
RETURN
