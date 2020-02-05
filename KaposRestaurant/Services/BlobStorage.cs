using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaposRestaurant.Services
{
    public static class BlobStorage
    {
        public static string guardarImagen(string filename, string blobReference)
        {
            StorageCredentials credentials = new StorageCredentials("proyectoblobstorage", "x6q/bmEQExsn29HDqfq2TeqH4u3Yb8La68zmm3Udol58TlRK8COaNMRxdXnrcx5g11PuIzAwi+z14m/eUq6H2Q==");
            CloudStorageAccount storageacc = new CloudStorageAccount(credentials, true);

            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("imagenesproyecto");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);
            blockBlob.UploadFromFile(filename);

            return blockBlob.Uri.AbsoluteUri;
        }



    }
}
