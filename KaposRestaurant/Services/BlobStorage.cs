using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaposRestaurant.Services
{
    class BlobStorage
    {
        CloudStorageAccount storageacc;
        StorageCredentials credentials;

        public BlobStorage()
        {
            credentials = new StorageCredentials("proyectoblobstorage", "x6q/bmEQExsn29HDqfq2TeqH4u3Yb8La68zmm3Udol58TlRK8COaNMRxdXnrcx5g11PuIzAwi+z14m/eUq6H2Q==");
            storageacc = new CloudStorageAccount(credentials, false);
        }



    }
}
