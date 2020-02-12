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
        private static readonly StorageCredentials credentials = new StorageCredentials(Properties.Settings.Default.AccountName, Properties.Settings.Default.KeyValue);
        private static readonly CloudStorageAccount storageacc = new CloudStorageAccount(credentials, true);
        private static readonly CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
        private static readonly CloudBlobContainer container = blobClient.GetContainerReference(Properties.Settings.Default.ContainerName);

        public static string guardarImagen(string filename, string blobReference)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);
            blockBlob.UploadFromFile(filename);

            return blockBlob.Uri.AbsoluteUri;
        }

        public static void eliminarImagen(string blobReference)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobReference);

            if (blockBlob.Exists())
            {
                blockBlob.Delete();
            }
        }



    }
}
