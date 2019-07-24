using AngularCSharp_AddAssetApp.Models;
using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularCSharp_AddAssetApp.Controllers
{
    public class AssetsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<AssetViewModel> GetAllAssets()
        {
            return _unitOfWork.Assets.FindAll()
                              .Select(a => new AssetViewModel
                              {
                                  AssetId = a.AssetId,
                                  FileName = a.FileName,
                                  CreatedBy = a.CreatedBy,
                                  MimeTypeName = (a.MimeType == null) ? string.Empty : a.MimeType.MimeTypeName,
                                  CountryName = (a.Country == null) ? string.Empty : a.Country.CountryName,
                                  Email = a.Email,
                                  Description = a.Description
                              });
        }

        [HttpPut]
        public HttpResponseMessage UpdateAsset(AssetViewModel changedAsset)
        {
            try
            {
                var existingAsset = _unitOfWork.Assets.Get(changedAsset.AssetId);
                if (existingAsset == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Entity was not found!");
                }

                UpdateAsset(existingAsset, changedAsset);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddAsset(AssetViewModel newAsset)
        {
            try
            {
                var addedAsset = AddNewAsset(newAsset);
                return Request.CreateResponse(HttpStatusCode.OK, addedAsset.AssetId);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAsset(Guid id)
        {
            try
            {
                Asset existingAsset = _unitOfWork.Assets.Get(id);
                if (existingAsset == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Entity was not found!");
                }

                _unitOfWork.Assets.Remove(existingAsset);
                _unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private void UpdateAsset(Asset existingAsset, AssetViewModel updatedAssetViewModel)
        {
            CopyAssetViewModelToAsset(updatedAssetViewModel, existingAsset);
            _unitOfWork.Save();
        }

        private Asset AddNewAsset(AssetViewModel newAssetViewModel)
        {
            var newAsset = new Asset();
            CopyAssetViewModelToAsset(newAssetViewModel, newAsset);

            var addedEntity = _unitOfWork.Assets.Add(newAsset);
            _unitOfWork.Save();

            return addedEntity;
        }

        private void CopyAssetViewModelToAsset(AssetViewModel assetViewModel, Asset asset)
        {
            asset.FileName = assetViewModel.FileName;
            asset.Description = assetViewModel.Description;
            asset.CreatedBy = assetViewModel.CreatedBy;
            asset.Email = assetViewModel.Email;

            if (string.IsNullOrWhiteSpace(assetViewModel.CountryName))
            {
                asset.Country = null;
            }
            else
            {
                asset.Country = _unitOfWork.Countries.GetByCountryName(assetViewModel.CountryName) ?? new Country { CountryName = assetViewModel.CountryName };
            }

            if (string.IsNullOrWhiteSpace(assetViewModel.MimeTypeName))
            {
                asset.MimeType = null;
            }
            else
            {
                asset.MimeType = _unitOfWork.MimeTypes.GetByMimeTypeName(assetViewModel.MimeTypeName) ?? new MimeType { MimeTypeName = assetViewModel.MimeTypeName };
            }
        }
    }
}
