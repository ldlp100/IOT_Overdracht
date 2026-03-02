PACKAGE MANAGER CONSOLE
	// Add migration
	add-migration V100 -Context IoTDBContext
	// Update database
	update-database v100 -context IoTDbContext
	// Remove latest migration
	remove-migration -context IoTDbContext