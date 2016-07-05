using ISMSPush.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISMSPush
{
    public interface IDatabaseFileManager
    {
		void AttachDatabases (DatabaseState databaseState);
		String SeedDb (string databaseName, string newDatabaseName);
        
    }
}
