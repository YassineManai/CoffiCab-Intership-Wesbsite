using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManufacturingExecutionSystem1.Service
{
  public class ProductRepository : IRepository<Product>
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product model)
        {
            var pr = await _context.Product.AddAsync(model);
            await _context.SaveChangesAsync();
            return pr.Entity;
        }

        public async Task Delete(string code)
        {
            var pr = await _context.Product.FirstOrDefaultAsync(p => p.ItemCode == code);
            if (pr != null)
            {

                _context.Product.Remove(pr);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
        return await _context.Product.FirstOrDefaultAsync(p => p.IDProduct == id);
      
        }
    public async Task<Product> GetByCode(string code)
    {
      return await _context.Product.FirstOrDefaultAsync(p => p.ItemCode == code);
    }
    public async Task<Product> Update(Product productDTO)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p =>p.ItemCode == productDTO.ItemCode); 
            if(product != null)
            {
        product.TypeProduct = productDTO.TypeProduct; product.ItemDesc = productDTO.ItemDesc; product.ParentItemCode = productDTO.ParentItemCode; product.Image = productDTO.Image; product.CodeProcess = productDTO.CodeProcess; product.ParentIDProduct = productDTO.ParentIDProduct
                ; product.CodeItemModel = productDTO.CodeItemModel; product.ITemGroup = productDTO.ITemGroup; product.Warehouse = productDTO.Warehouse; product.ConsumptionPerOneKM_outPut = productDTO.ConsumptionPerOneKM_outPut; product.CodePAC = productDTO.CodePAC; product.COdeTPV = productDTO.COdeTPV; product.CodeItemNature = productDTO.CodeItemNature
                ; product.LocalItemCode = productDTO.LocalItemCode; product.CodeRecette = productDTO.CodeRecette; product.Speed = productDTO.Speed; product.CunsumptionCopperKgPerOneKM = productDTO.CunsumptionCopperKgPerOneKM; product.CunsumptionPVCKgPerOneKM = productDTO.CunsumptionPVCKgPerOneKM
                ; product.Famille = productDTO.Famille; product.Section = productDTO.Section; product.Couleur = productDTO.Couleur; product.couleurP = productDTO.couleurP; product.couleurS = productDTO.couleurS; product.TypeMatiere = productDTO.TypeMatiere; product.Diametre = productDTO.Diametre
                ; product.m_min_m_sec = productDTO.m_min_m_sec; product.CodePAC_DVR = productDTO.CodePAC_DVR; product.CodeItemModel_DVR = productDTO.CodeItemModel_DVR; product.Code_Recette_DVR = productDTO.Code_Recette_DVR; product.With_Rewinder = productDTO.With_Rewinder; product.FG = productDTO.FG; product.InforItem = productDTO.InforItem
                ; product.Warehouse_WIP = productDTO.Warehouse_WIP; product.ResistanceOptimal = productDTO.ResistanceOptimal; product.CodeTPV_DVR = productDTO.CodeTPV_DVR; product.Poids_Conducteur_Kg_Km = productDTO.Poids_Conducteur_Kg_Km; product.Poids_Insolation_Kg_Km = productDTO.Poids_Insolation_Kg_Km; product.Couleur_Marquage = productDTO.Couleur_Marquage;
                await _context.SaveChangesAsync();
                return product;

            }
            return null;
        }
    public bool DataExist(string code)
    {
      return _context.Product.Any(d => d.ItemCode.ToString() == code);
    }
  }
}
