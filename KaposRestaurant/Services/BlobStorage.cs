using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaposRestaurant.Services
{
    public static class BlobStorage
    {
        private static readonly CloudStorageAccount storageacc;
        private static readonly StorageCredentials credentials;
        private static readonly CloudBlobClient blobClient;

        static BlobStorage()
        {
            credentials = new StorageCredentials("proyectoblobstorage", "x6q/bmEQExsn29HDqfq2TeqH4u3Yb8La68zmm3Udol58TlRK8COaNMRxdXnrcx5g11PuIzAwi+z14m/eUq6H2Q==");
            storageacc = new CloudStorageAccount(credentials, false);
            blobClient = storageacc.CreateCloudBlobClient();
        }

        public static void guardarImagen(string filename)
        {
            CloudBlobContainer container = blobClient.GetContainerReference("democontainer");

            container.CreateIfNotExists();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("DemoBlob");
        }



    }
}
