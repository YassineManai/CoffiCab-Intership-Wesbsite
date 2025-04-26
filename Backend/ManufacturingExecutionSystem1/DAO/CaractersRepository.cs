
using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System;
using ManufacturingExecutionSystem1.Data;
using ManufacturingExecutionSystem1.entities;
namespace ManufacturingExecutionSystem1.Service
{
  public class CaractersRepository : IRepository<Caracters>
    {
        public Context _context;
        public CaractersRepository(Context context) {
        _context = context;
        }
        public async Task<Caracters> Add(Caracters model)
        {
            var car = await _context.Caracters.AddAsync(model);
            await _context.SaveChangesAsync();
            return car.Entity;
        }

        public async Task Delete(string code)
        {
            var car = await _context.Caracters.FirstOrDefaultAsync(c => c.CodeCaracter == code);
            if(car != null) {
            _context.Caracters.Remove(car);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<IEnumerable<Caracters>> GetAll()
        {
            return await _context.Caracters.ToListAsync();
        }

        public async Task<Caracters> GetById(int id)
        {
      return await _context.Caracters.FirstOrDefaultAsync(c => c.IDCaracters == id);
      
        }
    public async Task<Caracters> GetByCode(string code)
    {
      return await _context.Caracters.FirstOrDefaultAsync(p => p.CodeCaracter == code);
    }
    public async Task<Caracters> Update(Caracters caracterDTO)
        {
            var caracter = await _context.Caracters.FirstOrDefaultAsync(c=>c.CodeCaracter ==  caracterDTO.CodeCaracter);
            if(caracter != null) {

                caracter.DescCaracter = caracterDTO.DescCaracter;
                caracter.Unit_of_measure = caracterDTO.Unit_of_measure;
                caracter.WithMaxMinValue = caracterDTO.WithMaxMinValue;
                caracter.Visual_Value = caracterDTO.Visual_Value;
                caracter.IsUCS = caracterDTO.IsUCS;
                caracter.Activated = caracterDTO.Activated;
                caracter.IsSearchCreteria = caracterDTO.IsSearchCreteria;
                caracter.Visible_InProductionView = caracterDTO.Visible_InProductionView;
                caracter.VisibleInQualityView = caracterDTO.VisibleInQualityView;
                caracter.Valeur = caracterDTO.Valeur;
                caracter.Type = caracterDTO.Type;
                caracter.IsDatasheet = caracterDTO.IsDatasheet;
                caracter.CodeProcess = caracterDTO.CodeProcess;
                caracter.ForInput = caracterDTO.ForInput;
                caracter.MasqueSaisie = caracterDTO.MasqueSaisie;
                caracter.Regroupement_Libille = caracterDTO.Regroupement_Libille;
                caracter.Ordre_Regroupement_Libille = caracterDTO.Ordre_Regroupement_Libille;
                caracter.Ordre_Caracter = caracterDTO.Ordre_Caracter;
                caracter.ParamStartOfShift = caracterDTO.ParamStartOfShift;
                caracter.Code_OPC = caracterDTO.Code_OPC;
                caracter.LocalDescCaracter = caracterDTO.LocalDescCaracter;
                caracter.IsToolingParameter = caracterDTO.IsToolingParameter;
                caracter.IsSpeed = caracterDTO.IsSpeed;
                caracter.Saisie_Automatique = caracterDTO.Saisie_Automatique;
                caracter.IsRepetitif = caracterDTO.IsRepetitif;
                caracter.Lien_Cararactere_Nb_Repetition = caracterDTO.Lien_Cararactere_Nb_Repetition;
                caracter.IsResistance = caracterDTO.IsResistance;
                caracter.Print_Character_In_Separate_Label = caracterDTO.Print_Character_In_Separate_Label;
                caracter.Activer_Controle_Soumission = caracterDTO.Activer_Controle_Soumission;
                await _context.SaveChangesAsync();
                return caracter;
            }
            return null;
        }
    public bool DataExist(string code)
    {
      return _context.Caracters.Any(d => d.CodeCaracter.ToString() == code);
    }
  }
}
